import axios from "axios";
import apiUtils from "../utils/apiUtils";

const warningSentenceModalService = () => {
    const URL = apiUtils.getUrl();

    const getRenameContent = async (warningSentenceId) => {
        try {
            const response = await axios.get(URL + `/warningsentence/modal/rename/${warningSentenceId}`);
            return response.data;
        } catch (error) {
            throw new Error('Error fetching modal content');
        }
    };

    const getCopyContent = async (warningSentenceIds) => {
        try {
            const queryParams = warningSentenceIds.map(id => `ids=${id}`).join('&');
            const response = await axios.get(`${URL}/warningsentence/modal/copy?${queryParams}`);
            return response.data;
        } catch (error) {
            throw new Error('Error fetching modal content');
        }
    };


    const getDeleteContent = async (warningSentenceIds) => {
        try {
            const queryParams = warningSentenceIds.map(id => `ids=${id}`).join('&');
            const response = await axios.get(`${URL}/warningsentence/modal/delete?${queryParams}`);
            return response.data;
        } catch (error) {
            throw new Error('Error fetching modal content');
        }
    };

    return {
        getRenameContent,
        getCopyContent,
        getDeleteContent
    };
};

export default warningSentenceModalService();