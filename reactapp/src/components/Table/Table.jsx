import React from 'react';
import './Table.css';

const Table = ({ jobList, sortingCriteria, keyWordForSearch}) => {

    const sortAscByDate = (jobs) => {
        console.log('Called sortAscByDate');
        
        jobs.sort((a, b) => {
            const dateA = new Date(a.publishDate);
            const dateB = new Date(b.publishDate);
            return dateA.getTime() - dateB.getTime();
        });

        return jobs;
    }

    const sortDescByDate = (jobs) => {
        console.log('Called sortDescByDate');

        jobs.sort((a, b) => {
            const dateA = new Date(a.publishDate);
            const dateB = new Date(b.publishDate);
            return dateB.getTime() - dateA.getTime();
        });


        return jobs;
    }

    const filterByKeyWord = (jobs, keyWord) => { //Search is done just for position, not company or country
        console.log('Called filterByKeyWord');

        var filteredJobs = jobs.filter((job) => {            
            var jobPositionLower = job.position.toString().toLowerCase();            
            return jobPositionLower.includes(keyWord);
        })        
        return filteredJobs;
    }

    var displayData = [];
    if (jobList) {
        console.log("Filtering and sorting jobs");        
        var filteredData = keyWordForSearch ? filterByKeyWord(jobList, keyWordForSearch) : jobList;
        var sortedData = sortingCriteria == 'Asc' ? sortAscByDate(filteredData) : sortDescByDate(filteredData);        
        displayData = sortedData ?? [];
    }

    else {
        console.log('Job list is empty');
    }


    return (        
        <div className="table">            
            <div className="row header">
                <div className="cell">Position</div>
                <div className="cell">Company</div>
                <div className="cell">Country</div>
                <div className="cell">Publish date</div>
                <div className="cell">Details</div>
            </div>
            {displayData.map((job) => (
             <div className="row" key={job.id}>
                <div className="cell">{job.position}</div>
                <div className="cell">{job.companyName}</div>
                <div className="cell">{job.countryName}</div>
                <div className="cell">{job.publishDate.split("T")[0]}</div>
                <div className="cell">
                    <a href={job.jobLink}>Go to details</a>
                </div>
            </div>             
            )) }
        </div>
    )
}

export default Table;
