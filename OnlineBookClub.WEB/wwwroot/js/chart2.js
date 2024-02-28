const context = document.getElementById('GenderArea');

new Chart(context, {
    type: 'polarArea',
    data: {
        labels: ['Erkek', 'Kız'],
        datasets: [{
            label: '# of Votes',
            data: [12, 19],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});