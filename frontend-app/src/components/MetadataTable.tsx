import React, { useEffect, useState } from 'react';
import { PdfMetadata } from '../types/PdfMetadata ';
import {
  Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Typography,
  Button
} from '@mui/material';
import { getAllPDFs } from '../services/PdfService';
import { useNavigate } from 'react-router-dom';


const MetadataTable: React.FC = () => {
  const navigator = useNavigate();
  const [pdfs, setPdfsLists] = useState<PdfMetadata[]>([]);
  const [search, setSearch] = useState<string>("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(""); 

  const fetchData = async () => {
    setLoading(true); 
    setError("");
    debugger;
    try {
      const responseData = await getAllPDFs(search);
      console.log("metadataLists",responseData.data.metadataLists);
      setPdfsLists(responseData?.data?.metadataLists ?? []);
    } catch (error) {  
      debugger;    
      setError("There was an error fetching the data. Please try again.");
    } finally {
      setLoading(false); 
    }
  };
  

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <>
    <Button onClick={(e) => {navigator("/upload")}}>Upload File</Button>
    {loading && <p>Loading...</p>} 
    {error && <p style={{ color: 'red' }}>{error}</p>} 
    {(pdfs.length > 0) ? (    
      <>
    <h1>PDF Metadata Lists</h1>
   
    <TableContainer component={Paper} sx={{ mt: 4 }}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>File Id</TableCell>
            <TableCell>File Name</TableCell>
            <TableCell>Title</TableCell>
            <TableCell>Author</TableCell>
            <TableCell>Pages</TableCell>
            <TableCell>Created</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {pdfs.map((pdf) => (
            <TableRow key={pdf.id}>
              <TableCell>{pdf.id}</TableCell>
              <TableCell>{pdf.fileName}</TableCell>
              <TableCell>{pdf.title}</TableCell>
              <TableCell>{pdf.author}</TableCell>
              <TableCell>{pdf.pageCount}</TableCell>
              <TableCell>{pdf.creationDate}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
    </>  
  ) : (!loading  && <Typography mt={4}>No results to show.</Typography>)
}
</>
)
};

export default MetadataTable;
