import { TestBed } from '@angular/core/testing';

import { SimpleSnackBarService } from './simple-snack-bar.service';

describe('SimpleSnackBarService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SimpleSnackBarService = TestBed.get(SimpleSnackBarService);
    expect(service).toBeTruthy();
  });
});
