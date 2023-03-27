// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------------------------------

import React from 'react';
import { MessageForm } from './MessageForm';
import { Nav } from './Nav';

import './App.css';

function App() {
  return (
    <div className="App">
      <Nav />
      <MessageForm />
      <h5>LZSS</h5>
      <p>Uso del algoritmo LZSS</p>
      <ol>
        <li>Con el topic A, enviar el texto a comprimir</li>
        <li>El consumidor de C# comprimirá y mostrará el texto en consola</li>
        <li>Con el topic B, enviar el texto a descomprimir</li>
        <li>El consumidor de C# descomprimirá y mostrará el texto en consola</li>
      </ol>
    </div>
  );
}

export default App;
