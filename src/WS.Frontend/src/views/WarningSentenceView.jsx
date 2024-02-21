import ActionBarWarningSentencesView from '../components/actions/ActionBarWarningSentencesView';
import warningSentenceService from '../services/warningSentenceService';
import ShwSpinner from "../components/spinners/ShwSpinner";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Table } from 'react-bootstrap';
import { useParams } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const WarningSentenceView = () => {
    const [warningSentence, setWarningSentence] = useState({});
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

    return (
        <div>
            <ActionBarWarningSentencesView
                editAction={editWarningSentence}
                backAction={navigateBack}
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
                            <Col xs={2} className="pictogram-col">
                                <img src={`/pictograms/${warningSentence.warningPictogram.pictogram}.${warningSentence.warningPictogram.extension}`} alt="Piktogram" className="view-pictogram" />
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
        </div>
    )
}

export default WarningSentenceView;
