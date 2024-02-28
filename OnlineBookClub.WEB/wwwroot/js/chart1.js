const context2 = document.getElementById('MonthlyEventArea');

new Chart(context2, {
    type: 'line',
    data: {
        labels: ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'],
        datasets: [{
            label: '# of Votes',
            data: [120, 90, 194, 172, 150, 100, 75, 135, 88, 90, 62, 40,],
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