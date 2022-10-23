function getSortedTickets(arr, sortingCriteria) {


    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = [];

    for (let stringInfo of arr) {
        stringInfo = stringInfo.split('|');
        tickets.push(new Ticket(stringInfo[0], Number(stringInfo[1]), stringInfo[2]));
    }

    if (sortingCriteria == 'destination') {
        tickets.sort((a,b)=> a.destination.localeCompare(b.destination));
    }
    else if (sortingCriteria == 'price') {
        tickets.sort((a,b)=> {b.price - a.price});
    }
    else if (sortingCriteria == 'status') {
        tickets.sort((a,b)=> a.status.localeCompare(b.status));
    }

    return tickets;
} 

let tickets=getSortedTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);

for (let ticket of tickets) {
   console.log(ticket.destination + ticket.price+ ticket.status); 
}