import React from 'react';
import './ToolBar.css'

const Toolbar = ({ onSearch, onSort }) => {
    return (
        <div className="toolbar">
            <input type="text" placeholder="Search position..." onChange={onSearch} />            
            <button onClick={() => onSort('Asc')}>Sort by Date (Asc)</button>
            <button onClick={() => onSort('Desc')}>Sort by Date (Desc)</button>
        </div>
    );
};

export default Toolbar;