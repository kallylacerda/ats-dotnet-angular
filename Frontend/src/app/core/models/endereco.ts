export interface Uf {
  id: string;
  nome: string;
  sigla: string;
}

export interface Municipio {
  id: string;
  nome: string;
  uf: Uf;
}

export interface Endereco {
  cep: string;
  logradouro: string;
  numero: string;
  municipio: Municipio;
}
