import React, { useState } from 'react';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

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

const DeleteWarningSentenceModal = ({ isOpen, closeModal }) => {
    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={closeModal}
            style={customStyles}
            contentLabel="Edit Warning Sentence Modal"
        >
            <div className="modal-top-section">
                <h5 className="modal-header">Slet H-sætning(er)</h5>
                <div className="close-icon" onClick={closeModal}>
                    <FontAwesomeIcon icon={faTimes} />
                </div>
            </div>
            <div className="modal-middle-section">

            </div>
            <div className="modal-bottom-section">
                <button className="right btn btn-outline-danger">Slet</button>
            </div>
        </Modal>
    );
};

export default DeleteWarningSentenceModal;