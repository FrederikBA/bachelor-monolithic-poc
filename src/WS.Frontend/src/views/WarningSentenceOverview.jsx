import ActionBarWarningSentences from "../components/actions/ActionBarWarningSentences";
import ShwSpinner from "../components/spinners/ShwSpinner";
import warningSentenceService from "../services/warningSentenceService";
import { Table } from 'react-bootstrap';
import { useState, useEffect } from 'react';

const WarningSentenceOverview = () => {
    const [warningSentences, setWarningSentences] = useState([]);
    const [checkedWarningSentences, setCheckedWarningSentences] = useState({});
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await warningSentenceService.getAllWarningSentences();
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

    const handleActionButtonClick = () => {
        const checkedSentenceIds = Object.entries(checkedWarningSentences)
            .filter(([id, isChecked]) => isChecked)
            .map(([id, isChecked]) => id);

        if (checkedSentenceIds.length > 0) {
            console.log("Selected warning sentence IDs:", checkedSentenceIds);
        }
    };

    return (
        <div className="center">
            <ActionBarWarningSentences
                action={handleActionButtonClick}
                hasCheckedSentences={Object.values(checkedWarningSentences).some(value => value)}
            />
            <Table>
                <thead>
                    <tr>
                        <th className="table-header table-ws-category">Kategori</th>
                        <th className="table-header th-ws-title">H-sætning</th>
                        <th className="table-header">Pitkogram nummer</th>
                        <th className="table-header">Piktogram</th>
                        <th className="table-header">Fareklasse (WIP)</th>
                        <th className="table-header">Signalord</th>
                        <th className="table-header table-ws-text">Ordlyd af H-sætning</th>
                        <th className="table-header table-checkbox"></th>
                    </tr>
                </thead>
                {!loading && (
                    <tbody>
                        {warningSentences.map(sentence => (
                            <tr className="table-row" key={sentence.id}>
                                <td className="table-item table-item-ws table-ws-category table-ws-category-border">{sentence.warningCategory.text}</td>
                                <td className="table-item table-item-ws"><span className="td-ws-title">{sentence.code}</span></td>
                                <td className="table-item table-item-ws">{sentence.warningPictogram.code}</td>
                                <td className="table-item table-item-ws"><img src={`pictograms/${sentence.warningPictogram.pictogram}.${sentence.warningPictogram.extension}`} alt="Piktogram" className="pictogram" /></td>
                                <td className="table-item table-item-ws"></td>
                                <td className="table-item table-item-ws">{sentence.warningSignalWord.signalWordText}</td>
                                <td className="table-item table-item-ws table-ws-text table-ws-text-border">{sentence.text}</td>
                                <td className="table-item table-item-ws table-checkbox table-checkbox-border">
                                    <input
                                        type="checkbox"
                                        onChange={(e) => handleCheckboxChange(sentence.id, e.target.checked)}
                                    />
                                </td>
                            </tr>
                        ))}
                    </tbody>
                )}
            </Table>
            {loading && <ShwSpinner />}
        </div>
    )
}

export default WarningSentenceOverview;
