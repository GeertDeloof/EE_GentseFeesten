using DomainController;
using DomainController.Repository;
using Persistence;
using Presentation;



// Persistence
IEvenementRepository repo2022 = new EvenementMapper2022();
// Domeincontroller
DomeinController domainController = new DomeinController(repo2022);
// Presentation
GfApplicatie gf = new GfApplicatie(domainController);