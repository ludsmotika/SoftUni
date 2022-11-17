function loadRepos() {
	let username = document.getElementById('username').value;

	fetch(`https://api.github.com/users/${username}/repos`)
		.then(result => {
			if (result.status != '200') {
				throw new Error("invalid input");
			}
			return result.json();
		})
		.then(data => handleData(data))
		.catch(err => handleError(err));

}

function handleData(data) {
	let outputField = document.getElementById('repos');
	outputField.innerHTML = '';

	for (current of data) {
		let li = document.createElement('li');
		let a = document.createElement('a');
		a.href = current.html_url;
		a.textContent = current.full_name;
		li.appendChild(a);
		outputField.appendChild(li);
	}
}

function handleError(err) {
	let outputField = document.getElementById('repos');
	outputField.innerHTML = '';
	let p = document.createElement('p');
	p.textContent = `${err.message}`;
	outputField.appendChild(p);
}