import ActionBar from "../components/actions/ActionBar"
import ShwSpinner from "../components/spinners/ShwSpinner"
import productService from "../services/productService"
import apiUtils from "../utils/apiUtils"


import { useState, useEffect } from 'react'

const ProductOverview = () => {
    const [products, setProducts] = useState({});

    useEffect(() => {
        const getProducts = async () => {
            try {
                const response = await productService.getAllproducts()
                setProducts(response);
                console.log(response);
            } catch (error) {
                console.log(error);
            }
        }
        getProducts()
    }, []);

    return (
        <div className="center">
            <ActionBar />
            <h1>ProductOverview</h1>
            <ShwSpinner />
        </div>
    )
}

export default ProductOverview