import React from "react";
import s from './ProductCategoryRow.module.css';

interface ProductCategoryRowProps {
    category: string;
}
  
const ProductCategoryRow: React.FC<ProductCategoryRowProps> = ({ category }) => {
    return (
      <tr>
        <th colSpan={2} className={s.table}>{category}</th>
      </tr>
    );
}

export default ProductCategoryRow