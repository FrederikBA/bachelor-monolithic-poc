import React, { useState, useEffect } from 'react';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

//Services
import warningSentenceModalService from '../../services/warningSentenceModalService';
import warningSentenceService from '../../services/warningSentenceService';

//Utils
import listUtils from "../../utils/listUtils";

const customStyles = {
    content: {
        top: '50%',
        left: '50%',
        right: 'auto',
        bottom: 'auto',
        marginRight: '-50%',
        transform: 'translate(-50%, -50%)',
        width: '800px',
        padding: '0'
    },
};

Modal.setAppElement('#root');

const DeleteWarningSentenceModal = ({ isOpen, closeModal, content, onDelete, notifySuccess, notifyError }) => {
    const [warningSentences, setWarningSentences] = useState([{}]);
    const checkedSentenceIds = Object.entries(content)
        .filter(([id, isChecked]) => isChecked)
        .map(([id, isChecked]) => id);

    useEffect(() => {
        if (isOpen) {
            if (checkedSentenceIds.length > 0) {
                const fetchData = async () => {
                    try {
                        const response = await warningSentenceModalService.getCopyContent(checkedSentenceIds);
                        setWarningSentences(response);
                    } catch (error) {
                        console.log(error);
                    }
                };
                fetchData();
            }
        }
    }, [isOpen, content]);

    const deleteWarningSentences = async () => {
        try {
            const checkedIdsasNumber = listUtils.stringToNumbers(checkedSentenceIds)

            await warningSentenceService.deleteWarningSentences(checkedIdsasNumber);
            notifySuccess("H-sætning(er) slettet.")
            onDelete();
            closeModal();
        } catch (error) {
            notifyError('Der opstod en fejl.');
        }
    };

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={closeModal}
            style={customStyles}
            contentLabel="Delete Warning Sentence Modal"
        >
            <div className="modal-top-section">
                <h5 className="modal-header">Slet H-sætning(er)</h5>
                <div className="close-icon" onClick={closeModal}>
                    <FontAwesomeIcon icon={faTimes} />
                </div>
            </div>
            <div className="modal-middle-section">
                <ul>
                    {warningSentences.map((item) => (
                        <li key={item.id}>{item.code}</li>
                    ))}
                </ul>
            </div>
            <div className="modal-bottom-section">
                <button onClick={deleteWarningSentences} className="right btn btn-outline-danger">Slet</button>
            </div>
        </Modal>
    );
};

export default DeleteWarningSentenceModal;
