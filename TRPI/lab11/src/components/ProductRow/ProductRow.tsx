import React from "react";
import s from './ProductRow.module.css';

interface Product {
    stocked: boolean;
    name: string;
    price: string;
}
  
interface ProductRowProps {
    product: Product;
}
  
const ProductRow: React.FC<ProductRowProps> = ({ product }) => {
    const name = product.stocked ? (
      product.name
    ) : (
      <span style={{ color: 'red' }}>{product.name}</span>
    );
  
    return (
      <tr className={s.row}>
        <td>{name}</td>
        <td>{product.price}</td>
      </tr>
    );
}

export default ProductRow