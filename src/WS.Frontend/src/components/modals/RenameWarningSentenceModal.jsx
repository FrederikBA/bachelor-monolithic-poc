import React, { useState, useEffect } from 'react';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

//Services
import warningSentenceModalService from '../../services/warningSentenceModalService';
import warningSentenceService from '../../services/warningSentenceService';

//Utils


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

const RenameWarningSentenceModal = ({ isOpen, closeModal, content, onRename, notifySuccess, notifyError }) => {
    const [inputValue, setInputValue] = useState('');
    const [warningSentence, setWarningSentence] = useState({});
    const checkedSentenceIds = Object.entries(content)
        .filter(([id, isChecked]) => isChecked)
        .map(([id, isChecked]) => id);

    useEffect(() => {
        if (isOpen) {
            if (checkedSentenceIds.length === 1) {
                const fetchData = async () => {
                    try {
                        const response = await warningSentenceModalService.getRenameContent(checkedSentenceIds[0]);
                        setInputValue(response.code);
                        setWarningSentence(response)
                    } catch (error) {
                    }
                };
                fetchData();
            }
        }
    }, [isOpen, content]);

    const handleInputChange = (e) => {
        setInputValue(e.target.value);
    };

    const handleKeyDown = (e) => {
        if (e.key === 'Enter') {
            renameWarningSentence();
        }
    };

    const renameWarningSentence = async () => {
        try {
            await warningSentenceService.renameWarningSentence(warningSentence.id, inputValue);
            notifySuccess("H-sætning omdøbt.")
            onRename();
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
            contentLabel="Edit Warning Sentence Modal"
        >
            <div className="modal-top-section">
                <h5 className="modal-header">Omdøb H-sætning</h5>
                <div className="close-icon" onClick={closeModal}>
                    <FontAwesomeIcon icon={faTimes} />
                </div>
            </div>
            <div className="modal-middle-section">
                <input
                    className="form-control form-select-md"
                    type="text"
                    placeholder=""
                    aria-label=".form-control-lg example"
                    value={inputValue}
                    onChange={handleInputChange}
                    onKeyDown={handleKeyDown}
                />
                <label className={inputValue ? "input-label input-label-up" : "input-label"}>
                    Omdøb kode
                </label>
            </div>
            <div className="modal-bottom-section">
                <button onClick={renameWarningSentence} className="right btn btn-outline-primary">Gem</button>
            </div>
        </Modal>
    );
};

export default RenameWarningSentenceModal;
