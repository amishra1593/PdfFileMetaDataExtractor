import React from 'react';
import { Box, Button, TextField } from '@mui/material';

interface Props {
  title: string;
  author: string;
  onTitleChange: (val: string) => void;
  onAuthorChange: (val: string) => void;
  onSearch: () => void;
}

const SearchBar: React.FC<Props> = ({ title, author, onTitleChange, onAuthorChange, onSearch }) => {
  return (
    <Box display="flex" flexWrap="wrap" gap={2} alignItems="center">
    <TextField
      label="Title"
      value={title}
      onChange={(e) => onTitleChange(e.target.value)}
      size="small"
    />
    <TextField
      label="Author"
      value={author}
      onChange={(e) => onAuthorChange(e.target.value)}
      size="small"
    />
    <Button variant="outlined" onClick={onSearch} sx={{ height: '40px' }}>
      Search
    </Button>
  </Box>
  
  );
};

export default SearchBar;
