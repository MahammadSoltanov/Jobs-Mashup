import React from 'react';
import './Table.css';

const Table = ({ jobsList, sortingCriteria, keyWordForSearch}) => {

    const sortAscByDate = (jobs) => {

    }

    const sortDescByDate = (jobs) => {

    }

    const filterByKeyWord = (jobs, keyWordForSearch) => { //Search is done just for position, not company or country

    }

    const displayData = [];
    if (jobsList) {

        filteredData = keyWordForSearch ? filterByKeyWord(jobsList, keyWordForSearch) : jobsList;
        sortedData = sortingCriteria == 'Asc' ? sortAscByDate(filteredData) : sortDescByDate(filteredData);
        displayData = sortedData ?? []; 
    }


    return (
        <div class="table">
            <div class="row header">
                <div class="cell">Position</div>
                <div class="cell">Company</div>
                <div class="cell">Country</div>
                <div class="cell">Publish date</div>
                <div class="cell">Details</div>
            </div>
            {displayData.map((job) => (
                <div class="row" key={job.id}>
                <div class="cell">{job.position}</div>
                <div class="cell">{job.companyName}</div>
                <div class="cell">{job.countryName}</div>
                <div class="cell">{job.publishDate}</div>
                <div class="cell">
                    <a>{job.jobLink}</a>
                </div>
            </div>             
            )) }
        </div>
    )
}

export default Table;
