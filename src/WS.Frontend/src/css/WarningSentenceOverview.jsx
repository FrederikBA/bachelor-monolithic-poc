import ActionBar from "../components/actions/ActionBar"
import ShwSpinner from "../components/spinners/ShwSpinner"
import warningSentenceService from "../services/warningSentenceService"
import { Table } from 'react-bootstrap';
import { useState, useEffect } from 'react';

const WarningSentenceOverview = () => {
    const [warningSentences, setWarningSentences] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await warningSentenceService.getAllWarningSentences();
                setWarningSentences(response);
                console.log(response);
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

    return (
        <div className="center">
            <ActionBar />
            <Table>
                <thead>
                    <tr>
                        <th className="table-header">Kategori</th>
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
                                <td className="table-item table-item-ws">{sentence.warningCategory.text}</td>
                                <td className="table-item table-item-ws">{sentence.code}</td>
                                <td className="table-item table-item-ws">{sentence.warningPictogram.code}</td>
                                <td className="table-item table-item-ws"><img src={`pictograms/${sentence.warningPictogram.pictogram}.${sentence.warningPictogram.extension}`} alt="Piktogram" className="pictogram" /></td>
                                <td className="table-item table-item-ws"></td>
                                <td className="table-item table-item-ws">{sentence.warningSignalWord.signalWordText}</td>
                                <td className="table-item table-item-ws table-ws-text table-ws-text-border">{sentence.text}</td>
                                <td className="table-item table-item-ws table-checkbox table-checkbox-border"><input type="checkbox" /></td>
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
