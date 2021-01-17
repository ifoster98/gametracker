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

  it('should show MatchSelection as current page if logged in', () => {
    service.login(42);
    expect(service.currentPage()).toEqual(ViewPage.MatchSelection);
  });
});
