import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import ShwSpinner from "../components/spinners/ShwSpinner";
import SidebarFilter from "../components/sidebar/SidebarFilter";
import ActionBarWarningSentencesOverview from '../components/actions/ActionBarWarningSentencesOverview';
import warningSentenceService from "../services/warningSentenceService";
import { Table } from 'react-bootstrap';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

const WarningSentenceOverview = () => {
    const [warningSentences, setWarningSentences] = useState([]);
    const [checkedWarningSentences, setCheckedWarningSentences] = useState({});
    const [loading, setLoading] = useState(true);
    const [filters, setFilters] = useState({
        kategori: {
            fysiske: false,
            miljø: false,
            sundhedsmæssige: false
        },
        signalord: {
            fare: false,
            advarsel: false
        }
    });

    const navigate = useNavigate();

    useEffect(() => {
        const fetchData = async () => {
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
            } finally {
                setTimeout(() => {
                    setLoading(false);
                }, 1000);
            }
        };

        fetchData();
    }, []);

    const handleCheckboxChange = (sentenceId, isChecked) => {
        setCheckedWarningSentences(prevState => ({
            ...prevState,
            [sentenceId]: isChecked,
        }));
    };

    const handleFilterChange = (filterType, filterName, isChecked) => {
        setFilters(prevFilters => ({
            ...prevFilters,
            [filterType]: {
                ...prevFilters[filterType],
                [filterName]: isChecked
            }
        }));
    };

    const handleSelectAllClick = () => {
        const allChecked = Object.values(checkedWarningSentences).every(value => value);

        const updatedCheckedSentences = {};
        warningSentences.forEach(sentence => {
            updatedCheckedSentences[sentence.id] = !allChecked;
        });

        setCheckedWarningSentences(updatedCheckedSentences);
    };

    const handleActionButtonClick = () => {
        const checkedSentenceIds = Object.entries(checkedWarningSentences)
            .filter(([id, isChecked]) => isChecked)
            .map(([id, isChecked]) => id);

        if (checkedSentenceIds.length > 0) {
            console.log("Selected warning sentence IDs:", checkedSentenceIds);
        }
    };

    const navigateToWarningSentence = (id) => {
        navigate(`/warningsentence/${id}`)
    }

    const applyFilters = (sentence) => {
        const { kategori, signalord } = filters;

        if (!Object.values(kategori).some(value => value) && !Object.values(signalord).some(value => value)) {
            return true;
        }

        const categoryMatch =
            (kategori.fysiske && sentence.warningCategory.text === 'Fysiske') ||
            (kategori.miljø && sentence.warningCategory.text === 'Miljø') ||
            (kategori.sundhedsmæssige && sentence.warningCategory.text === 'Sundhedsmæssige');

        const signalWordMatch =
            (signalord.fare && sentence.warningSignalWord.signalWordText === 'Fare') ||
            (signalord.advarsel && sentence.warningSignalWord.signalWordText === 'Advarsel');

        return categoryMatch || signalWordMatch;
    };


    return (
        <div>
            <ActionBarWarningSentencesOverview
                action={handleActionButtonClick}
                selectAllAction={handleSelectAllClick}
                hasCheckedSentences={Object.values(checkedWarningSentences).some(value => value)}
            />
            <Container fluid>
                <Row className="overview-row">
                    <Col sm={2}>
                        <SidebarFilter onFilterChange={handleFilterChange} filters={filters} />
                    </Col>
                    <Col sm={10}>
                        <div className="content">
                            <Table>
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th className="table-header th-ws-title">H-sætning</th>
                                        <th className="table-header">Piktogram nr.</th>
                                        <th className="table-header">Piktogram</th>
                                        <th className="table-header table-ws-category">Kategori</th>
                                        <th className="table-header">Signalord</th>
                                        <th className="table-header table-ws-text">Ordlyd af H-sætning</th>
                                        <th className="table-header table-checkbox"></th>
                                    </tr>
                                </thead>
                                {!loading && (
                                    <tbody>
                                        {warningSentences.map(sentence => (
                                            applyFilters(sentence) && (
                                                <tr className="table-row" key={sentence.id}>
                                                    <td></td>
                                                    <td className="table-item table-item-ws">
                                                        <span onClick={() => navigateToWarningSentence(sentence.id)} className="td-ws-title">
                                                            {sentence.code}
                                                        </span>
                                                    </td>
                                                    <td className="table-item table-item-ws">{sentence.warningPictogram.code}</td>
                                                    <td className="table-item table-item-ws"><img src={`pictograms/${sentence.warningPictogram.pictogram}.${sentence.warningPictogram.extension}`} alt="Piktogram" className="pictogram" /></td>
                                                    <td className="table-item table-item-ws table-ws-category">{sentence.warningCategory.text}</td>
                                                    <td className="table-item table-item-ws">{sentence.warningSignalWord.signalWordText}</td>
                                                    <td className="table-item table-item-ws table-ws-text table-ws-text-border">{sentence.text}</td>
                                                    <td className="table-item table-item-ws table-checkbox table-checkbox-border">
                                                        <input
                                                            type="checkbox"
                                                            onChange={(e) => handleCheckboxChange(sentence.id, e.target.checked)}
                                                            checked={checkedWarningSentences[sentence.id] || false}
                                                        />
                                                    </td>
                                                </tr>
                                            )
                                        ))}
                                    </tbody>
                                )}
                            </Table>
                            <div className="spinner-container">
                                {loading && <ShwSpinner />}
                            </div>

                        </div>
                    </Col>
                </Row>
            </Container >
        </div>
    )
}

export default WarningSentenceOverview;
