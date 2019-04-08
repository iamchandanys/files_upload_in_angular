import { TestBed } from '@angular/core/testing';

import { ToLocalFolderService } from './to-local-folder.service';

describe('ToLocalFolderService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ToLocalFolderService = TestBed.get(ToLocalFolderService);
    expect(service).toBeTruthy();
  });
});
