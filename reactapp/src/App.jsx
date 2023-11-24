import React, { Component, useState, useEffect } from 'react';
import Table from './components/Table/Table';
import Toolbar from './components/ToolBar/ToolBar';
import fetchJobsFromApi from './api/jobApi'
import './App.css';

const App = () => {
    const [sortingCriteria, setSortingCriteria] = useState('Desc');
    const [keyWord, setKeyWord] = useState(null)
    const [jobsCollection, setJobsCollection] = useState();        
    const handleSort = (criteria) => {
        console.log("Called handleSort");
        setSortingCriteria(criteria);
    };

    const handleSearch = (keyWord) => {
        console.log("Called handleSearch");
        setKeyWord(keyWord)
    }

    useEffect(() => {
        console.log("Called useEffect");

        const fetchData = async () => {
            const jobList = await fetchJobsFromApi();            
            setJobsCollection(jobList);
        };

        fetchData();
    }, []);

    return (
        <div className='App'>            
            <Toolbar onSort={handleSort} onSearch={handleSearch}></Toolbar>
            <Table jobList = {jobsCollection} sortingCriteria={sortingCriteria} keyWordForSearch={keyWord}></Table>
        </div>
    );

}

export default App;