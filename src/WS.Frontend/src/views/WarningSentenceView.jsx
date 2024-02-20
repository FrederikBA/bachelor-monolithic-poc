import ActionBarWarningSentencesView from '../components/actions/ActionBarWarningSentencesView';
import warningSentenceService from '../services/warningSentenceService';
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
                }, 1000);
            }
        };

        fetchData();
    }, []);

    const editWarningSentence = () => {
        console.log("Edit button pressed");
    }

    const navigateBack = () => {
        navigate('/warningsentences')
    }

    return (
        <div className="center">
            <ActionBarWarningSentencesView
                editAction={editWarningSentence}
                backAction={navigateBack}
            />
            <h1>Warning Sentence View: {sentenceId}</h1>
        </div>
    )
}

export default WarningSentenceView