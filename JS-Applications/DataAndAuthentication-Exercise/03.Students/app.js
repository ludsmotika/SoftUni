attachEvents();

function attachEvents() {
    let form = document.getElementById('form');
    form.addEventListener('submit', submitStudent);
}

async function submitStudent(e) {
    e.preventDefault();
    let formData = new FormData(e.target);
    let studentInfo = Object.fromEntries(formData);

    if (studentInfo.firstName == '' || studentInfo.lastName == '' || studentInfo.facultyNumber == '' || studentInfo.grade == '') {
        return;
    }

    await postStudent(studentInfo);
    await loadStudents();
}

async function postStudent(student) {

    let res = await fetch('http://localhost:3030/jsonstore/collections/students', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(student)
    })

    if (res.status != 200) {
        alert('Error');
    }

    return await res.json();
}

async function loadStudents() {
    let outputElement = document.getElementById('results').children[1];
    outputElement.innerHTML = '';

    let data = await getStudents();

    for (let key in data) {
        let tr = document.createElement('tr');
        let firstNameTH = document.createElement('th');
        firstNameTH.textContent = data[key].firstName;
        let lastNameTH = document.createElement('th');
        lastNameTH.textContent = data[key].lastName;
        let FacultyNumberTH = document.createElement('th');
        FacultyNumberTH.textContent = data[key].facultyNumber;
        let gradeTH = document.createElement('th');
        gradeTH.textContent = data[key].grade;

        tr.appendChild(firstNameTH);
        tr.appendChild(lastNameTH);
        tr.appendChild(FacultyNumberTH);
        tr.appendChild(gradeTH);
        outputElement.appendChild(tr);
    }
}

async function getStudents() {
    let res = await fetch('http://localhost:3030/jsonstore/collections/students');
    let data = await res.json();
    return data;
}