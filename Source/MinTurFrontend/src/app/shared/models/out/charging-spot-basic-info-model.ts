import { RegionBasicInfoModel } from './region-basic-info-model';

export interface ChargingSpotBasicInfoModel {
  id: number;
  name: string;
  address: string;
  description: string;
  region: RegionBasicInfoModel;
}
