import { TestBed } from '@angular/core/testing';

import { PsuedoNgrxService, ViewPage } from './psuedo-ngrx.service';

describe('PsuedoNgrxService', () => {
  let service: PsuedoNgrxService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PsuedoNgrxService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should not have a user id on initialisation', () => {
    expect(service.getUserId()).toBeUndefined();
    expect(service.isLoggedIn()).toBeFalse();
  })

  it('should have a user id after logging in', () => {
    service.login(42);
    expect(service.getUserId()).toEqual(42);
    expect(service.isLoggedIn()).toBeTrue();
  });

  it('should not have a user id after logging out', () => {
    service.logout();
    expect(service.getUserId()).toBeUndefined();
    expect(service.isLoggedIn()).toBeFalse();
  });

  it('should show None as current page if not logged in', () => {
    expect(service.currentPage()).toEqual(ViewPage.None);
  });

  it('should show MatchSelection as current page if logged in and no match selected', () => {
    service.login(42);
    expect(service.currentPage()).toEqual(ViewPage.MatchSelection);
  });

  it('should not have a match id on initialisation', () => {
    expect(service.getMatchId()).toBeUndefined();
  });

  it('should have a match id after choosing a match', () => {
    service.chooseMatch(22);
    expect(service.getMatchId()).toEqual(22);
  });

  it('should not have a match id after ending the match', () => {
    service.endMatch();
    expect(service.getMatchId()).toBeUndefined();
  });

  it('should show EventEntry as current page if logged in and match is selected', () => {
    service.login(42);
    service.chooseMatch(22);
    expect(service.currentPage()).toEqual(ViewPage.EventEntry);
  });

  it('should not have a match id after logging out', () => {
    service.login(42);
    service.chooseMatch(22);
    expect(service.getMatchId()).toEqual(22);
    service.logout();
    expect(service.getMatchId()).toBeUndefined();
  });
});
