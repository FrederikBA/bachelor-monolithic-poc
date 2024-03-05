import React, { useState, useEffect } from 'react';
import Modal from 'react-modal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes } from '@fortawesome/free-solid-svg-icons';

//React Bootstrap
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

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

const EditWarningSentenceModal = ({ isOpen, closeModal, onEdit, notifySuccess, notifyError, sentenceId, content }) => {
    const [warningSentence, setWarningSentence] = useState({
        code: "",
        text: "",
        warningTypeId: 2,
        warningCategoryId: 0,
        warningPictogramId: 0,
        warningSignalWordId: 0
    });
    const [selectedCategory, setSelectedCategory] = useState('');
    const [selectedPictogram, setSelectedPictogram] = useState('');
    const [selectedSignalWord, setSelectedSignalWord] = useState('');
    const [categories, setCategories] = useState([]);
    const [pictograms, setPictograms] = useState([]);
    const [signalWords, setSignalWords] = useState([]);

    useEffect(() => {
        if (isOpen) {
            const fetchData = async () => {
                try {
                    const response = await warningSentenceModalService.getEditContent(sentenceId);
                    setCategories(response.warningCategories);
                    setWarningSentence({
                        code: content.code || "",
                        text: content.text || "",
                        warningTypeId: 2,
                        warningCategoryId: content.warningCategory ? content.warningCategory.id : 0,
                        warningPictogramId: content.warningPictogram ? content.warningPictogram.id : 0,
                        warningSignalWordId: content.warningSignalWord ? content.warningSignalWord.id : 0
                    });
                    setPictograms(response.warningPictograms);
                    setSignalWords(response.warningSignalWords);

                    // Select the correct pictogram
                    setSelectedPictogram(content.warningPictogram ? content.warningPictogram.id : 0);
                } catch (error) {
                    console.log(error);
                }
            };
            fetchData();
        }
    }, [isOpen, sentenceId, content]);

    const handleInput = (event) => {
        const { id, value } = event.target;
        setWarningSentence({ ...warningSentence, [id]: value });
    };

    const handlePictogramSelection = (warningPictogramId) => {
        setWarningSentence(prevState => ({
            ...prevState,
            warningPictogramId: warningPictogramId
        }));
        setSelectedPictogram(warningPictogramId);
    };

    const editWarningSentence = async () => {
        try {
            // await warningSentenceService.createWarningSentence(warningSentence)
            notifySuccess("H-sætning ændret.")
            onEdit();
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
            <Container>
                <div className="modal-top-section">
                    <h5 className="modal-header">Rediger H-sætning</h5>
                    <div className="close-icon" onClick={closeModal}>
                        <FontAwesomeIcon icon={faTimes} />
                    </div>
                </div>
                <div className="modal-middle-section">
                    <form>
                        <Row className="modal-row">
                            <input
                                className="form-control form-select-md create-input"
                                id="code"
                                type="text"
                                placeholder="H-sætning"
                                aria-label=".form-control-lg example"
                                value={warningSentence.code}
                                onChange={handleInput}
                            />
                            <input
                                className="form-control form-select-md create-input"
                                id="text"
                                type="text"
                                placeholder="Ordlyd af H-sætning"
                                aria-label=".form-control-lg example"
                                value={warningSentence.text}
                                onChange={handleInput}
                            />
                        </Row>
                        <Row className="modal-row">
                            <Col>
                                <div className="create-select pictogram-select">
                                    <div className="image-select">
                                        {pictograms.map(pictogram => (
                                            <img
                                                key={pictogram.id}
                                                src={`../pictograms/${pictogram.pictogram}.${pictogram.extension}`}
                                                alt={pictogram.code}
                                                className={selectedPictogram === pictogram.id ? 'selected' : ''}
                                                onClick={() => handlePictogramSelection(pictogram.id)}
                                            />
                                        ))}
                                    </div>
                                </div>
                            </Col>
                            <Col>
                                <div className="create-select">
                                    <select
                                        className="form-control form-select-md"
                                        id="warningCategoryId"
                                        value={warningSentence.warningCategoryId}
                                        onChange={handleInput}
                                    >
                                        <option value="">Vælg kategori</option>
                                        {categories.map(category => (
                                            <option key={category.id} value={category.id}>{category.text}</option>
                                        ))}
                                    </select>
                                </div>
                            </Col>
                            <Col>
                                <div className="create-select">
                                    <select
                                        className="form-control form-select-md"
                                        id="warningSignalWordId"
                                        value={warningSentence.warningSignalWordId}
                                        onChange={handleInput}
                                    >
                                        <option value="">Vælg signalord</option>
                                        {signalWords.map(signalWord => (
                                            <option key={signalWord.id} value={signalWord.id}>{signalWord.signalWordText}</option>
                                        ))}
                                    </select>
                                </div>
                            </Col>
                        </Row>
                    </form>
                </div>
                <div className="modal-bottom-section">
                    <button onClick={editWarningSentence} className="right btn btn-outline-primary">Gem</button>
                </div>
            </Container>
        </Modal >
    );
};

export default EditWarningSentenceModal;
