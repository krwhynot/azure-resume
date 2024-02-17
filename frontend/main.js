window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
})
const functioApi = 'https://krresume.azurewebsites.net/api/GetResumeCounter?code=W45LukJ2lkYJciYLOtycYswnIqIJ2C1_lcaMCXjxnDzvAzFuaGeufw==';

const getVisitCount = () => {
    let count = 30;
    fetch(functioApi).then(response => {
        return response.json()
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    });
    return count;
}
