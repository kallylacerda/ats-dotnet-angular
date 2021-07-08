import { Endereco } from './endereco';

export interface Candidato {
  id: string;
  nomeCompleto: string;
  email: string;
  cpf: string;
  telefone: string;
  dataNascimento: string;
  descricao: string;
  createdAt: string;
  updatedAt?: string;
  endereco?: Endereco;
}
