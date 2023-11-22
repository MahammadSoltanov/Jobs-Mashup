import React, { Component, useState } from 'react';
import Table from './components/Table/Table';
import Toolbar from './components/ToolBar/ToolBar';
import './App.css';

export default class App extends Component {
    static displayName = App.name;

    render() {
        const [sortingCriteria, setSortingCriteria] = useState('Desc');
        const [keyWord, setKeyWord] = useState(null)

        const handleSort = (criteria) => {
            setSortingCriteria(criteria);
        };

        const handleSearch = (keyWord) => {
            setKeyWord(keyWord)
        }

        return (
            <div className='App'>
                <Toolbar onSort={handleSort} onSearch={handleSearch}></Toolbar>
                <Table sortingCriteria={sortingCriteria} keyWordForSearch={keyWord}></Table>
            </div>
        );
    }

}
