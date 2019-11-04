import { TestBed } from '@angular/core/testing';

import { BaseHttpService } from './base-http.service';

describe('BaseHttpServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BaseHttpService= TestBed.get(BaseHttpService);
    expect(service).toBeTruthy();
  });
});
