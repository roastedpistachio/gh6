class RiskHeaderController {
  constructor() {
    this.name = 'riskHeader';
    this.riskTypes = {
      ALL: 'At risk in my area',
      MY_AREA: 'All at risk in St. Louis',
      MY_CLIENTS: 'My Clients'
    }
  }
  setFilter(filter) {
    this.filterChanged({ filter: filter });
  }
}

export default RiskHeaderController;
