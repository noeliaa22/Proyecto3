// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

console.log(fechas);
console.log(numPlanesDia);

let ctx = document.getElementById('myCanvas');
let myCanvas = new Chart(ctx, {
    // The type of chart we want to create
    type: 'line',

    // The data for our dataset
    data: {
        labels: fechas,
        datasets: [{
            label: 'PLANES CREADOS LA ÚLTIMA SEMANA',
            backgroundColor: 'transparent',
            color: '#9a681d',
            borderColor: '#2e2e88d4',
            data: numPlanesDia,
        }]
    },

    // Configuration options go here
    options: {
        scales: {
            yAxes: [{
                stacked: true
            }]
        }
    }
});

console.log(tipos);
console.log(numPlanesTipo);

let ctx2 = document.getElementById('myDoughnutChart');
let myDoughnutChart = new Chart(ctx2, {
    type: 'doughnut',
    data: {
        labels: tipos,
        datasets: [{
            label: 'PLANES POR TIPO',
            backgroundColor: 'transparent',
            borderColor: '#2e2e88d4',
            data: numPlanesTipo,
        }]
    },

    // Configuration options go here
    options: {}
});