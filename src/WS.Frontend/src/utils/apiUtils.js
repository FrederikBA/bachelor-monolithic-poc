const URL = 'http://localhost:5075/api';

const api = () => {

    const getUrl = () => {
        return URL;
    }

    return {
        getUrl
    }
}

export default api();