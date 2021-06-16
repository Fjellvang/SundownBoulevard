// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const submitForm = function (e) {
	e.preventDefault();
	console.log("hello");
	const email = document.getElementById('email').value;
	const xhttp = new XMLHttpRequest();
	xhttp.open("POST", `/api/booking/booktable?email=${email}`, true);
	xhttp.send();
	//fetch("/api/booking/booktable");
}

const form = document.getElementById('form');
form.addEventListener('submit', submitForm);
