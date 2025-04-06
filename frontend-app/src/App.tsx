import React, { useEffect, useState } from 'react';
import { Container, Typography } from '@mui/material';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { PdfMetadata } from './types/PdfMetadata ';
import FileUpload from './components/FileUpload';
import MetadataTable from './components/MetadataTable';
import { getAllPDFs } from './services/PdfService';

const App: React.FC = () => {
  

  return (
    <Container maxWidth="md">
      {/* <Typography variant="h4" mt={4}>PDF Metadata Extractor</Typography> */}
      {/* <FileUpload onUploadSuccess={fetchData} /> */}
      {/* <SearchBar
        title={title}
        author={author}
        onTitleChange={setTitle}
        onAuthorChange={setAuthor}
        onSearch={fetchData}
      /> */}
      {/* <MetadataTable data={pdfs} /> */}

      <Router>
      <div>
        
        <Routes>
          {/* Define your routes */}
          <Route path="/" element={<MetadataTable />} />
          <Route path="/upload" element={<FileUpload />} />
        </Routes>
      </div>
    </Router>
    </Container>
  );
};

export default App;
