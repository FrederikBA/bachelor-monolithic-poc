import axios from "axios";
import apiUtils from "../utils/apiUtils";

const warningSentenceService = () => {
    const URL = apiUtils.getUrl();

    const getAllWarningSentences = async () => {
        try {
            const response = await axios.get(URL + '/warningsentence/all');
            return response.data;
        } catch (error) {
            throw new Error('Error fetching warning sentences');
        }
    };

    const getWarningSentenceById = async (warningSentenceId) => {
        try {
            const response = await axios.get(`${URL}/warningsentence/${warningSentenceId}`);
            return response.data;
        } catch (error) {
            throw new Error(`Error fetching warning sentence with id: ${warningSentenceId}`);
        }
    };

    const renameWarningSentence = async (warningSentenceId, name) => {
        try {
            const response = await axios.put(`${URL}/WarningSentence/rename/${warningSentenceId}?newName=${name}`);
            return response.data;
        } catch (error) {
            throw new Error('Error renaming warning sentence');
        }
    };


    return {
        getAllWarningSentences,
        getWarningSentenceById,
        renameWarningSentence
    };
};

export default warningSentenceService();