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

    return {
        getRenameContent
    };
};

export default warningSentenceModalService();