import axios from "axios";
import apiUtils from "../utils/apiUtils";

const productService = () => {
    const URL = apiUtils.getUrl();

    const getAllProducts = async () => {
        try {
            const response = await axios.get(URL + '/product/all');
            return response.data;
        } catch (error) {
            throw new Error('Error fetching products');
        }
    };

    const getProductById = async (productId) => {
        try {
            const response = await axios.get(`${URL}/product/${productId}`);
            return response.data;
        } catch (error) {
            throw new Error(`Error fetching product with id: ${productId}`);
        }
    };

    return {
        getAllProducts,
        getProductById
    };
};

export default productService();