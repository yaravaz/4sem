import React from "react";
import ProductCategoryRow from "../ProductCategoryRow/ProductCategoryRow";
import ProductRow from "../ProductRow/ProductRow";
import s from './ProductTable.module.css'

interface Product {
    category: string;
    price: string;
    stocked: boolean;
    name: string;
}
  
interface ProductTableProps {
    products: Product[];
    filterText: string;
    inStockOnly: boolean;
}
  
const ProductTable: React.FC<ProductTableProps> = ({ products, filterText, inStockOnly }) => {

    const filteredProducts = products
      .filter(
        (product) =>
          product.name.toLowerCase().indexOf(filterText.toLowerCase()) !== -1
      )
      .filter((product) => !inStockOnly || product.stocked);
    
      const rows = filteredProducts.map((product, index) => {
        const categoryRow =
          index === 0 || product.category !== filteredProducts[index - 1].category ? (
            <ProductCategoryRow
              category={product.category}
              key={product.category}
            />
          ) : null;
      
        return (
          <React.Fragment key={product.name}>
            {categoryRow}
            <ProductRow product={product} key={product.name} />
          </React.Fragment>
        );
      });
  
    return (
      <table>
        <thead >
          <tr >
            <th className={s.name}>Name</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>{rows}</tbody>
      </table>
    )
}
export default ProductTable