import React, {useState} from "react";
import SearchBar from "../SearchBar/SearchBar";
import ProductTable from "../ProductTable/ProductTable";
import s from './FilterableProductTable.module.css';

interface Product {
    category: string;
    price: string;
    stocked: boolean;
    name: string;
  }
  
interface FilterableProductTableProps {
    products: Product[];
}
  
const FilterableProductTable: React.FC<FilterableProductTableProps> = ({ products: initialProducts  }) => {
  const [filterText, setFilterText] = useState<string>('');
  const [inStockOnly, setInStockOnly] = useState<boolean>(false);
  const [newProductValue, setNewProductValue] = useState<string>('');
  const [products, setProducts] = useState<Product[]>(initialProducts);


  const handleFilterTextChange = (text: string) => {
    setFilterText(text);
  };

  const handleInStockChange = (checked: boolean) => {
    setInStockOnly(checked);
  };

  const handleNewValueChange = (newElem: string) => {
    setNewProductValue(newElem);
  };

  const handleAddProduct = () => {
    if (newProductValue.trim() !== '') {
      const newProduct: Product = {
        category: 'Sporting Goods',
        price: '$99.97',
        stocked: true,
        name: newProductValue,
      };

      const updatedProducts = [...products, newProduct];
      setProducts(updatedProducts);
      setNewProductValue('');
    }
  };


  return (
    <div className={s.con}>
      <SearchBar
        filterText={filterText}
        inStockOnly={inStockOnly}
        onFilterTextChange={handleFilterTextChange}
        onInStockChange={handleInStockChange}
        onNewValueChange={handleNewValueChange}
      />
      <button onClick={handleAddProduct}>Добавить</button>
      <ProductTable
        products={products}
        filterText={filterText}
        inStockOnly={inStockOnly}
      />
    </div>
  );
}

export default FilterableProductTable;