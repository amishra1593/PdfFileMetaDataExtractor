import React from 'react';
import { Container } from '@mui/material';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import FileUpload from './components/FileUpload';
import MetadataTable from './components/MetadataTable';

const App: React.FC = () => {
  return (
    <Container maxWidth="md">
      <Router>
      <div>
        <Routes>         
          <Route path="/" element={<FileUpload />} />
          <Route path="/list" element={<MetadataTable />} />
        </Routes>
      </div>
    </Router>
    </Container>
  );
};

export default App;
