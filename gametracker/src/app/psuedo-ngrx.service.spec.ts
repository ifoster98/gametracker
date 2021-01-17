import { TestBed } from '@angular/core/testing';

import { PsuedoNgrxService } from './psuedo-ngrx.service';

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
});
