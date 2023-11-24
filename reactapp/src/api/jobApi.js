const fetchJobsFromApi = async () => {
    try {
        console.log("Called fetchJobsFromApi");
        const response = await fetch('http://localhost:5021/api/Job');
        const data = await response.json();
        console.log(data);
        return data;
    }
    catch (error) {
        console.log("Error fetching data:", error);
        throw error;
    }
}

export default fetchJobsFromApi;