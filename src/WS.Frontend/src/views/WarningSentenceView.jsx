import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

//Components
import ActionBarWarningSentencesView from '../components/actions/ActionBarWarningSentencesView';
import EditWarningSentenceModal from '../components/modals/EditWarningSentenceModal';
import ShwSpinner from "../components/spinners/ShwSpinner";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

//Services
import warningSentenceService from '../services/warningSentenceService';

//Toast
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const WarningSentenceView = () => {
    const [warningSentence, setWarningSentence] = useState({});
    const [isEditModalOpen, setIsEditModalOpen] = useState(false);
    const [loading, setLoading] = useState(true);

    const navigate = useNavigate();
    const { sentenceId } = useParams();

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await warningSentenceService.getWarningSentenceById(sentenceId);
                setWarningSentence(response);
                console.log(response);
            } catch (error) {
                console.log(error);
            } finally {
                setTimeout(() => {
                    setLoading(false);
                }, 100);
            }
        };

        fetchData();
    }, [sentenceId]);

    const editWarningSentence = () => {
        console.log("Edit button pressed");
    }

    const navigateBack = () => {
        navigate('/warningsentences')
    }

    //Modal
    const openEditModal = () => {
        setIsEditModalOpen(true);
    };

    const closeEditModal = () => {
        setIsEditModalOpen(false);
    };

    //Modal Functions
    const refreshOverview = async () => {
        try {
            const response = await warningSentenceService.getAllWarningSentences();
            response.sort((a, b) => {
                if (a.code < b.code) return -1;
                if (a.code > b.code) return 1;
                return 0;
            });
            setWarningSentences(response);
        } catch (error) {
            console.log(error);
        }
    };

    //Toast
    const notifySuccess = (message) => {
        toast.success(message, { position: "bottom-right" });
    };

    const notifyError = (errorMessage) => {
        toast.error(errorMessage, { position: "bottom-right" });
    };

    return (
        <div>
            <ActionBarWarningSentencesView
                editAction={editWarningSentence}
                backAction={navigateBack}
                openEditModal={openEditModal}
            />
            {loading ? null : (
                <div className="ws-view-top-section">
                    <Container className="ws-view-container">
                        <Row>
                            <Col xs={2}>
                            </Col>
                            <Col className="headline" xs={2}>
                                <span className="area-title">{warningSentence.code}</span>
                            </Col>
                            <Col xs={6}>

                            </Col>
                        </Row>
                        <Row>
                            <Col xs={2}></Col>
                            <Col xs={8}>
                                <div className="area-title-content">
                                    <span>{warningSentence.text}</span>
                                </div>
                            </Col>
                            <Col xs={2}></Col>
                        </Row>
                    </Container>
                </div>
            )}
            {loading && (
                <div className="ws-view-top-section">
                    <Container className="ws-view-container">
                        <Row className="justify-content-center align-items-center">
                            <Col xs={12} className="text-center">
                                <ShwSpinner />
                            </Col>
                        </Row>
                    </Container>
                </div>
            )}
            <EditWarningSentenceModal
                isOpen={isEditModalOpen}
                closeModal={closeEditModal}
                onEdit={refreshOverview}
                notifySuccess={notifySuccess}
                notifyError={notifyError}
            />
            <ToastContainer />
        </div>
    )
}

export default WarningSentenceView;
