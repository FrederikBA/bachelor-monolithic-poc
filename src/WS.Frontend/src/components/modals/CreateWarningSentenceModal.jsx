import React, { useState, useEffect } from 'react';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

//Services
import warningSentenceModalService from '../../services/warningSentenceModalService';
import warningSentenceService from '../../services/warningSentenceService';

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

const CreateWarningSentenceModal = ({ isOpen, closeModal, content, onCreate, notifySuccess, notifyError }) => {
    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={closeModal}
            style={customStyles}
            contentLabel="Create Warning Sentence Modal"
        >
            <div className="modal-top-section">
                <h5 className="modal-header">Opret H-sætning</h5>
                <div className="close-icon" onClick={closeModal}>
                    <FontAwesomeIcon icon={faTimes} />
                </div>
            </div>
            <div className="modal-middle-section">
            </div>
            <div className="modal-bottom-section">
                <button className="right btn btn-outline-primary">Gem</button>
            </div>
        </Modal>
    );
};

export default CreateWarningSentenceModal;
