// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const submitForm = function (e) {
	e.preventDefault();
	const email = document.getElementById('email').value;
	const hour = document.getElementById('hour').value;
	const minute = document.getElementById('minute').value;
	const date = document.getElementById('orderDate').value;
	const guests = document.getElementById('numberOfGuests').value;

	const foodMenu = document.getElementById('foodMenu').value;
	const beerMenu = document.getElementById('beerMenu').value;

	const xhttp = new XMLHttpRequest();

	xhttp.onload = function () {
		const body = document.getElementById("modalBody");
		if (this.status === 200) {
			body.innerHTML = `Thank you for your order, see you on ${date} at ${hour}:${minute === "0" ? "00" : minute}`;
		} else {
			const response = JSON.parse(this.responseText);
			body.innerHTML = `Booking failed with message:<br>${response.title}`;
		}
		$('#exampleModal').modal({});
	}
	xhttp.open("POST", `/api/booking/booktable?email=${email}&day=${date}&hour=${hour}&minute=${minute}&numberOfGuests=${guests}&foodMenu=${foodMenu}&beerMenu=${beerMenu}`, true);
	xhttp.send();

	//fetch("/api/booking/booktable");
}

const PopulateMenu = async function (elementId, endpoint) {
	const select = document.getElementById(elementId);
	const response = await fetch(endpoint);
	const json = await response.json();

	for (let i = 0; i < json.length; i++) {
		let opt = document.createElement("option");
		opt.value = json[i].id;
		opt.innerHTML = json[i].name;
		select.appendChild(opt);
	}
}

PopulateMenu("foodMenu", "/api/menu/getfoodmenu");
PopulateMenu("beerMenu", "/api/menu/getbeermenu");
const form = document.getElementById('form');
form.addEventListener('submit', submitForm);
