import React, { useState, useEffect } from 'react';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

//Services
import warningSentenceModalService from '../../services/warningSentenceModalService';

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

const CopyWarningSentenceModal = ({ isOpen, closeModal, content }) => {
    const [warningSentences, setWarningSentences] = useState([{}]);

    useEffect(() => {
        if (isOpen) {
            const checkedSentenceIds = Object.entries(content)
                .filter(([id, isChecked]) => isChecked)
                .map(([id, isChecked]) => id);

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

    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={closeModal}
            style={customStyles}
            contentLabel="Edit Warning Sentence Modal"
        >
            <div className="modal-top-section">
                <h5 className="modal-header">Kopier H-sætning(er)</h5>
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
                <button className="right btn btn-outline-primary">Kopier</button>
            </div>
        </Modal>
    );
};

export default CopyWarningSentenceModal;
