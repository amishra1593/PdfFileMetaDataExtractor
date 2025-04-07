import axios from 'axios';
import { PDFsListResponse, PDFUploadResponse } from '../types/PdfMetadata ';

const API_BASE = 'http://localhost:5000/api/Files';

export const uploadPDF = (file: File) => {
  const formData = new FormData();
  formData.append('file', file);
  return axios.post<PDFUploadResponse>(`${API_BASE}/upload`, formData);
};

export const getAllPDFs = (search?: string) => {
  return axios.get<PDFsListResponse>(`${API_BASE}/lists?searchValue=${search}`);
};
