import { Table } from 'react-bootstrap';
import ActionBar from "../components/actions/ActionBar";
import ShwSpinner from "../components/spinners/ShwSpinner";
import productService from "../services/productService";
import { useState, useEffect } from 'react';

const ProductOverview = () => {
    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await productService.getAllproducts();
                setProducts(response);
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
                        <th className="table-header">PRODUCT NO.</th>
                        <th className="table-header table-product-name">PRODUCT NAME</th>
                        <th className="table-header table-producer">MANUFACTURER / SUPPLIER</th>
                        <th className="table-header">SHIPPING COMPANY NO.</th>
                        <th className="table-header">WHITELIST</th>
                        <th className="table-header">STATUS</th>
                        <th className="table-checkbox"></th>
                    </tr>
                </thead>
                {!loading && (
                    <tbody>
                        {products.map(product => (
                            <tr className="table-row" key={product.id}>
                                <td className="table-item">{product.id}</td>
                                <td className="table-item table-product-name">{product.name}</td>
                                <td className="table-item table-producer table-producer-border">{product.producer.companyName}</td>
                                <td className="table-item"></td>
                                <td className="table-item"></td>
                                <td className="table-item">{product.status.text}</td>
                                <td className="table-item table-checkbox table-checkbox-border"><input type="checkbox" /></td>
                            </tr>
                        ))}
                    </tbody>
                )}
            </Table>
            {loading && <ShwSpinner />}
        </div>
    )
}

export default ProductOverview;
