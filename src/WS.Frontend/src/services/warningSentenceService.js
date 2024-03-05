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

    const copyWarningSentences = async (warningSentenceIds) => {
        try {
            const response = await axios.post(`${URL}/WarningSentence/copy`, {
                ids: warningSentenceIds
            });
            return response.data;
        } catch (error) {
            throw new Error('Error copying warning sentence');
        }
    };

    const deleteWarningSentences = async (warningSentenceIds) => {
        try {
            const queryParams = warningSentenceIds.map(id => `ids=${id}`).join('&');
            const response = await axios.delete(`${URL}/WarningSentence/delete?${queryParams}`);
            return response.data;
        } catch (error) {
            throw new Error('Error deleting warning sentence');
        }
    };

    const createWarningSentence = async (warningSentence) => {
        try {
            const response = await axios.post(`${URL}/WarningSentence/add`, warningSentence);
            return response.data;
        } catch (error) {
            throw new Error('Error creating warning sentence');
        }
    };

    const editWarningSentence = async (id, warningSentence) => {
        try {
            const response = await axios.put(`${URL}/WarningSentence/update/${id}`, warningSentence);
            return response.data;
        } catch (error) {
            throw new Error('Error updating warning sentence');
        }
    };


    return {
        getAllWarningSentences,
        getWarningSentenceById,
        renameWarningSentence,
        copyWarningSentences,
        deleteWarningSentences,
        createWarningSentence,
        editWarningSentence
    };
};

export default warningSentenceService();