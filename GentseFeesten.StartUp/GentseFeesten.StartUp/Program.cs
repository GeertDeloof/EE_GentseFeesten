using DomainController;
using DomainController.Repository;
using Persistence;
using Presentation;



// Persistence
IEvenementRepository repo2022 = new EvenementMapper2022();
IFavorietenRepository favorieten = new FavorietenMapper();
// Domeincontroller
DomeinController domainController = new DomeinController(repo2022 , favorieten);
// Presentation
GfApplicatie gf = new GfApplicatie(domainController);