export type PdfMetadata  = {
    id: number;
    fileName: string;
    title: string;
    author: string;
    pageCount: number;
    creationDate: string;
    uploadedAt: string;
  }

  export type PDFUploadResponse = {
    fileMetaData : FileMedtaData
  }

  
  export type PDFsListResponse = {
    metadataLists : PdfMetadata[]
  }


  export type FileMedtaData = {
    fileName: string;
    title: string;
    author: string;
    pageCount: number;
    creationDate: string;
  }
  
